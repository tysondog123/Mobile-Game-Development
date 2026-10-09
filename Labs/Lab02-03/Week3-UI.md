
## current interfaces
| UI Component | Parent Object | Anchor Position | Pivot | Purpose | interactable |
| -- | -- | -- | -- | -- | -- |
| Player HP bar / text | Canvas UI | Top Middle of the screen |  | Display the players HP | No |
|Abilite wheel|Canvas UI|Center of the screen||Show the players the options for abilite upgrade|no|
|Abilite wheel Options|Abilite wheel UI|Center of the Abilite wheel UI||Allow the player to chose a abilite to upgrade|yes|
|pause menu|Canvas UI|Center of screen||display the pause menu options|No|
|Pause menu Resuem|Pause Menu Canvas UI|Center of Pause Menu||let the player resume play|Yes|
|Pause menu Exit|Pause Menu Canvas UI|Center of Pause Menu||Let player exit the game|Yes|
|main menu|Canvas UI|Center of screen||Display the options for the main menu|No|
|main menu play|Main Menu Canvas UI|Center of Main Menu||Let the player start the game|Yes|
|main menu Exit|Main Menu Canvas UI|Center of Main Menu||Let the player close the game|Yes|


## issues with swaping aspect ratio
| issue | where | Aspect compered to 16:9 as normal |
| -- | -- | 
| HP box Streches down| top left| 4:3 |
| HP Bar to low | Top middel | 4:3 |
| Pause Title Streching | Top of Pause menu | 4:3 |
| HP UI Covers pause ui | Top left | 4:3 |
| HP UI is not visible | Top Middle | 20:9 |

![Normal_1_UI__Image](./UI_Evidence/Normal_UI.png)
![Normal Pause Image](./UI_Evidence/Normal_Pause.png)
![4:3_UI_Image](./UI_Evidence/4-3_UI.png)
![4:3_Pause Image](./UI_Evidence/4-3_Pause.png)
![20:9_UI_Image](./UI_Evidence/20-9_UI.png)
![20:9_Pause Image](./UI_Evidence/20-9_Pause.png)


## UI Scaler
Current canvas scaler : Scale with screen size, This canvas is used for all 3, my refrence resolution is 1920 x 1080

![Original UI scaler](./UI_Evidence/Original_canvas_scaler_options.png)
These are the original settings that i used for the scaler options on my Canvas, after testing the diffrent settings ive changed the settings to 
the ones shown bellow due to it making my UI look the best over multiple diffrent diffrent aspect ratios, the only change was changing the
match width and hight to 0.5 due to most of my ui being closer to a cube than a rectangle
![Original UI scaler](./UI_Evidence/New_canvas_scaler_options.png)


