EXTERNAL place_actors(left_actor_name,right_actor_name)
EXTERNAL change_emotion(emotion,ID)
//Left = 0, Right =1
{place_actors("Actor","Actor1")}
{change_emotion("Angry",0)}
{change_emotion("Happy",1)}

Please help me,please...
-> london

== london ==


* At your service madame
 -> astonished
 
    
*I dont have time for that! 
-> nod


== astonished ==
There are monster's in our basement. Can you check that for me?


    -> prendingending


==prendingending==


+ [I will check it for you, my lady] ->ending
+ [I just have feeling, thats not fun...] ->musi


==musi==
Unfortunetly the "Maker's" make only this advendture already
+[If you say so...]
->ending

== nod ==
I m afraid this choice is mirage...
+[hmmm...dont have much choices]
-> ending


== ending
Prove you are brave enough! Go get them tiger!
-> END