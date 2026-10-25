# Game inefficiencies  
## bounded inefficencies
### 1. Lack of pooling 
#### issue
for the enimesis and projectiles, whenever they are killed or hit their target insted of moving them into a pool to be reused later they are
#### location 
Enemy spawner script and enemy controler script
#### Predicted cost catagory
CPU + Memory - i predict this will effect the CPU due to the game needing to create a new gameobject everytime, i think this will also slow memory down due
to it having to re-allocate the enimes every time
#### how its triggerd
when enemies  spawn or fire projectiles 
### 2. Updating Score Every frame 
#### issue
the score ui element is updated everyframe instead of whenever the value is changed
#### location 
game controller script
#### Predicted cost catagory
GPU - i think this will slow the gpu down due to it having to re-build the ui every time
#### how its triggerd
every new frame
### 3. Repeating serches
#### issue
instead of saving the variable once then refrencing it the scripts serch for the player every frame
#### location 
enemie and projectile scripts in update
#### Predicted cost catagory
CPU - i think this will effect the cpu becuse it will need to serch for the player multiple times a frame
#### how its triggerd
every frame
### 4. Enemie movement calculation
#### issue
enemies calculate their movement every frame instead
#### location 
Enemie controls script
#### Predicted cost catagory
i think this will slow the CPU down due to the magnitued of math
#### how its triggerd
every frame the enemies try to move