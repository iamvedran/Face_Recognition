using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace Face_Recognition
{
    public partial class Form1 : Form
    {
        private Capture videoCapture = null;
        private Image<Bgr, byte> currentFrame = null;
        private Mat frame = new Mat();

        private bool faceDetectionEnabled = false;
        CascadeClassifier faceCascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");

        private Image<Bgr, byte> faceResult = null;
        List<Image<Gray, byte>> trainedFaces = new List<Image<Gray, byte>>();
        List<int> personLabels = new List<int>();
        private bool enableSaveImage = false;

        private bool isTrained = false;

        private EigenFaceRecognizer recognizer;

        List<String> personNames = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            videoCapture = new Capture();
            videoCapture.ImageGrabbed += ProcessFrame;
            videoCapture.Start();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            //1: Video Capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);

                // face detection
                if (faceDetectionEnabled)
                {
                  
                    //Convert from Bgr to Gray Image
                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                    //Enhance the image to get better result
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    Rectangle[] faces = faceCascadeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);

                    //2: If faces detected
                    if (faces.Length > 0)
                    {
                        foreach (Rectangle face in faces)
                        {
                            //Draw square around each face 
                            CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            //3: Add Person 
                            //Assign the face to the picture Box face picDetected
                            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;
                            picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                            picDetected.Image = resultImage.Bitmap;

                            if (enableSaveImage)
                            {
                                //We will create a directory if does not exists!
                                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                                if (!Directory.Exists(path))
                                    Directory.CreateDirectory(path);

                                //to avoid hang GUI we will create a new task
                                Task.Run(() => {
                                    for (int i = 0; i < 1; i++)
                                    {
                                        //resize the image then saving it
                                        resultImage.Resize(200, 200, Inter.Cubic)
                                            .Save(path + @"\" + txtPersonName.Text +"_"+ DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                    }
                                });
                            }

                            enableSaveImage = false;

                            // Step 4: Recognize the face 
                            if (isTrained)
                            {
                                Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200,200,Inter.Cubic);
                                CvInvoke.EqualizeHist(grayFaceResult,grayFaceResult);
                                var result = recognizer.Predict(grayFaceResult);

                                Debug.WriteLine(result.Label+". "+result.Distance);
                                //Here results found known faces
                                if (result.Label != -1 && result.Distance < 7000)
                                {
                                    CvInvoke.PutText(currentFrame, personNames[result.Label], new Point(face.X - 2, face.Y - 4),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                }
                                //here results did not found any know faces
                                else
                                {
                                    CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 4),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                                }
                            }
                        }

                    }
                }

                // show image in picture box
                picCapture.Image = currentFrame.ToBitmap();
            }

            //Dispose the Current Frame after processing it to reduce the memory consumption.
            if (currentFrame != null)
            {
                currentFrame.Dispose();

            }
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            faceDetectionEnabled = true;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            isTrained = TrainImagesFromDir();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            enableSaveImage = true;
        }

        private bool TrainImagesFromDir()
        {
            int imagesCount = 0;
            double threshold = 7000;
            trainedFaces.Clear();
            personLabels.Clear();
            personNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200,200,Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage,trainedImage);
                    trainedFaces.Add(trainedImage);
                    personLabels.Add(imagesCount);
                    string name = file.Split('\\').Last().Split('_')[0]; 
                    personNames.Add(name);
                    imagesCount++;
                    Debug.WriteLine(imagesCount + ". " +name);
                }

                if (trainedFaces.Count() > 0)
                {
                    recognizer = new EigenFaceRecognizer(imagesCount, threshold);
                    recognizer.Train(trainedFaces.ToArray(), personLabels.ToArray());

                    isTrained = true;
                    Debug.WriteLine(imagesCount);
                    Debug.WriteLine(isTrained);
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;                
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return false;
            }
        }
    }
}
