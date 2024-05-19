# Digital Signage

This application is designed to display a variety of media content, including images, PowerPoint presentations, and videos, on a digital screen in the form of a slideshow. The application features "level images," which appear more frequently than other media content, allowing users to prioritize certain visuals.

## Features
- Displays images from the "Digital-Signage" folder in the "Documents" directory.
- Plays videos from the designated directory.
- Shows PowerPoint presentations (currently under bug fixing).
- Supports adding media while the application is running (work in progress).
- User interface for managing images and running text (work in progress).
- Local configurator application to customize media display chances.
- Configuration stored in the registry for remote administration via GPO (Group Policy Object).

## Installation
1. Clone the repository:
    ```sh
    git clone https://github.com/AviWind02/Digital-Signage.git
    ```
2. Open the project in your preferred C# development environment.
3. Resolve any dependencies or missing packages if prompted.
4. Build the solution.
5. Configure the application by adjusting settings such as folder paths and display preferences, if needed.
6. Run the application.

## Usage
Once running, the application cycles through available media content, displaying them on the screen. Adjust the frequency of "level images" to control their appearance compared to other media.

To add new media content while the application is running (work in progress):
1. Place the desired image or video file in the designated directory.
2. The application will automatically detect and incorporate the new media into the slideshow.

## Known Issues
- There is a bug affecting the display of PowerPoint presentations.

## Contributions
Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch for your contribution.
3. Make the necessary changes and commit them.
4. Push your branch to your forked repository.
5. Submit a pull request, explaining your changes.

## License
This project is licensed under the MIT License.

## About
The application is designed to display various media content on a digital screen as a slideshow.


