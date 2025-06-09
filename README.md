This Unity C# script provides comprehensive 2D camera control with the following features:

Features:
Mouse drag to pan the camera: Click and hold the left mouse button, then drag to move the camera smoothly.

Keyboard movement: Use W, A, S, D keys to move the camera in respective directions.

Run speed: Holding Shift increases the camera movement speed.

Edge scrolling: Moving the mouse cursor near the screen edges causes the camera to pan automatically in that direction.

Zoom in/out: Use the mouse scroll wheel to zoom the camera in and out (orthographic zoom).

How it works:
Mouse Drag:
When the left mouse button is pressed, the script records the world position under the cursor. As the mouse moves while held down, the camera moves inversely to the mouse movement, creating a drag-pan effect.

Keyboard Movement:
The script checks for WASD key inputs every frame. It moves the camera in the corresponding direction. If Shift is held, the movement speed is multiplied by a run factor.

Edge Scrolling:
The script checks if the mouse pointer is within a configurable pixel range from any screen edge. If so, the camera moves automatically toward that edge.

Zoom:
The script reads the mouse scroll wheel input and adjusts the camera’s orthographic size within minimum and maximum zoom limits.
