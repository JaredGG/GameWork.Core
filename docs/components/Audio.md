# Overview
Functionalities that facilitate playing and fading audio. AudioChannels are overridable for your platform specific implementation.

# Usage
1. Extend the items in the Platform Adapters folder with an implementation for your specific platform.

2. Create an AudioController, passing in the extended items.

3. Remember to call the controller's Tick method.

4. Enjoy the sound of some sweet, sweet music.