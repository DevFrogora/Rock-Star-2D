# Rock-Star-Game
    From Ruhit Rai,

# Star
    - we will have prefab for star ;
    -To generate Star  
        we are going to use Object Pool design pattern to keep our star objects ready
        we are going to spawn data in the given range  and also make sure the object will not drop on sphere
    - we will attach collider to our star so it can collide with rock

# Rock
    - we are going to use rigidbody to detect collider collision
    - Rigidbody : kinematic 
    - collider : trigger 
    - to give input our rock : we will used IDragHandler interface for dragging 
    - to move the rock we are going to screen to world position to get the position 
    - we will have bag to collect collided star

# UI
    - Ui manager will update ui  

communicating data between all the script we are using event delegate for loose coupling
