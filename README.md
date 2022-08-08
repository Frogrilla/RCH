# Room Code Hider
Allows you to customise the Gorilla Tag scoreboard header text to your liking - useful for hiding or revealing codes.
The initial purpose of this mod was to allow streamers to hide codes in public lobbies, or to show codes in privates to allow people to join.

### How the mod works:
When the scoreboard text changes, instead of using the game's text, my mod overrides the text to whatever you set it to. The currently used header can be changed on the Computer Interface on its own page. On this page you can also toggle whether the mod will override the scoreboard or not. While the mod relies on Computer Interface to allow the user to change the text, the mod does not require it to run. However, without Computer Interface, you can't change the custom header in game and the scoreboard text will stay as the first line in `Custom Headers.txt`.

### Customising your headers:
Once the mod has run once, a file called `Custom Headers.txt` will appear in the same folder as `RCH.dll`. Each line in the file is a custom header that you can change. You can have as many as you like. The text surrounded by curly braces is dynamic text. The next paragraph explains how it works and how to use it.


### Dynamic text:
Dynamic text is a feature which allows you to include some values into your custom header. They are all wrapped in curly braces. Instead of displaying the input, the output will be displayed on the scoreboard.

| Input | Output | Example |
| ------------- | ------------- | ------------- |
| `{name}` | Room code / ID | 5VA9 |
| `{region}` | The lobby's region (not necessarily yours) | EU |
| `{mode}` | The current gamemode | CASUAL |
| `{public}` | Whether the lobby is public or private | PUBLIC |
| `{count}` | Player count | 6 |
| `{max}` | Max players | 10 |
