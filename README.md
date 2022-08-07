# Room Code Hider
Allows you to customise the Gorilla Tag scoreboard header text to your liking - useful for hiding or revealing codes.
The initial purpose of this mod was to allow streamers to hide codes in public lobbies, or to show codes in privates to allow people to join.

### How the mod works:
When the scoreboard text changes, instead of using the game's text, my mod overrides the text to whatever you set it to. The currently used header can be changed on the Computer Interface on its own page. On this page you can also toggle whether the mod will override the scoreboard or not. While the mod relies on Computer Interface to allow the user to change the text, the mod does not require it to run.

### Customising your headers:
Once the mod has run once, a file called <b>Custom Headers.txt</b> will appear in the same folder as <b>RCH.dll</b>. Each line in the file is a custom header that you can change. You can have as many as you like. The text surrounded by curly braces is <b>dynamic text</b>. The next paragraph explains how it works and how to use it.


### Dynamic text:
Dynamic text is a feature which allows you to include some values into your custom header. They are all wrapped in curly braces. Instead of displaying the input, the output will be displayed on the scoreboard.

| Input | Output | Example |
| ------------- | ------------- | ------------- |
| {name} | Room code / ID | 5VA9 |
| {region} | The lobby's region (not necessarily yours) | EU |
| {mode} | The current gamemode | CASUAL |
| {public} | Whether the lobby is public or private | PUBLIC |
| {count} | Player count | 6 |
| {max} | Max players | 10 |
