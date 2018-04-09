# RandomUniqueNumber
*********This Program will generate a list of 10000 numbers in random order each time it is run.***********
          In the first approach, I wrote a method, that took a list of number and a maximum number as parameters, generate random number and insert the number in the list. 
This method is too slow specially for 10,000 numbers. 
          In the second approach, I try to resolve the problem by thinking like lottery. 
We have two bowls (lists), one of them is full with 10,000 balls and the other is empty. 
Then when we take one ball inside the first bawl(list), we remove it from the original bawl and put it in the second bawl. 
We wrote a function that took a list of number and maximum number as parameters, we created a list of possible values, we generate all possible values from 1 to the maximum (10,000). 
Iterate through the process by removing a random number from the possible values list and placing it in the list of number list. 
The specificity of this method is: Efficient and too fast. 



