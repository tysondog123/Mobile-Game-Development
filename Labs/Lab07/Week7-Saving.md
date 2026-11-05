# weel 7 saving lab 

## meaningful values 
HighScore: int
Coins: int 
DifficultyUnlock: int
| Per Device settings | Player Progress | 
|-|-|
| Volume | Score |
| Accesability | Coins |
| Haptics | Difficulty Unlocks |

## Jason Layout 
1. schema version - verison of the save file 
2. Save Version   - a UID refrence for the current save (identifies the player)
3. SaveCount      - how many times save data has been re-writen
4. TimeStamp      - When save was made 
5. Score 
6. Coins
7. Unlocked Difficulty

## Save Version converter 
// how an old save version is transferd into a new save version without corruption 

## how data is reset
### New Game 
### Reset settings 
### Delete Cloud save
