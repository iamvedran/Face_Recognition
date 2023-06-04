# Face Recognition Simple Project

This is a face recognition simple project implemented in C# using the Emgu.CV library. The application captures video from a camera and performs face detection and recognition in real-time.

## Installation

To run this project, follow the steps below:

1. Clone the repository or download the source code files.
2. Open the project in Visual Studio or any other C# development environment.
3. Make sure you have the Emgu.CV 3 library installed. You can download it from the [Emgu.CV website](http://www.emgu.com/wiki/index.php/Main_Page).
4. Build the project to resolve any dependencies and compile the code.
5. Run the application.

## Features

- **Video Capture**: The application captures video from a camera device.
- **Face Detection**: It uses the Haar cascade classifier to detect faces in the video stream.
- **Face Recognition**: The project supports face recognition using the EigenFace algorithm.
- **Training**: You can train the face recognition model by providing images of known persons. The images should be stored in the "TrainedImages" directory.
- **Real-time Recognition**: Detected faces are recognized in real-time, and their names are displayed on the video stream if they match a known person.
- **Save Images**: You can enable the application to save detected faces as images for further training.

## Usage

1. Click the "Capture" button to start capturing video from the camera.
2. To enable face detection, click the "Detect" button.
3. To add a new person to the training set, enter their name in the text box and click the "Add Person" button. The application will save their face as an image.
4. The application will recognize known faces in real-time and display their names on the video stream when you click "Recognize".

## Dependencies

- Emgu.CV: A cross-platform .NET wrapper for OpenCV, which provides image and video processing capabilities.

## Credits

This project utilizes the following resources:

- [Emgu.CV](http://www.emgu.com/wiki/index.php/Main_Page): The official website of the Emgu.CV library.
- [OpenCV](https://opencv.org/): The open-source computer vision library used by Emgu.CV.
- [Haar Cascade Classifier](https://docs.opencv.org/2.4/modules/objdetect/doc/cascade_classification.html): A machine learning-based approach for object detection, used for face detection in this project.
