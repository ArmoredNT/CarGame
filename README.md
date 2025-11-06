# CarGame

Object Pooling

https://drive.google.com/file/d/1hoFIkWLiVSMwmtOpJNNJtfiU7xZlFRAi/view?usp=sharing - google drive link with diagram

I'm using object pooling to spawn sprites that move down the screen. Every second a car spawns and they take 3 seconds to become inactive. 



void Update()

&nbsp;   {

&nbsp;       if (timeElapsed >= spawnTime)

&nbsp;       {

&nbsp;           timeElapsed = 0;



&nbsp;           int carIndex = ContainsInactiveCar();

&nbsp;           if (carIndex != -1 )

&nbsp;           {

&nbsp;               //create car

&nbsp;               car\[carIndex].gameObject.transform.position = spawnPoint + new Vector3(Random.Range(-spawnRange, spawnRange), 0f, 0f);

&nbsp;               car\[carIndex].Reset();

&nbsp;           }

&nbsp;           else

&nbsp;           {

&nbsp;               car.Add(Instantiate(carPrefab, spawnPoint + new Vector3(Random.Range(-spawnRange, spawnRange), 0f, 0f), Quaternion.identity).GetComponent<EnemyCar>());

&nbsp;           }

&nbsp;       }

&nbsp;       timeElapsed += Time.deltaTime;

&nbsp;   }



&nbsp;   int ContainsInactiveCar()

&nbsp;   {

&nbsp;       for (int i = 0; i < car.Count; i++)

&nbsp;       {

&nbsp;           if (car\[i].Active == false) return i;

&nbsp;       }



&nbsp;       return -1;

&nbsp;   }



Dirty Flag

https://drive.google.com/file/d/1HhZsuVbmR9w06TI6YPP5\_90blZoFkBxf/view?usp=sharing - dirty flag diagram

In the car script I use dirty flag to prevent checking the timer when the car is inactive. When the timer elaspses it sets a Boolean called active, if this is true the timer will no longer run until it is reset. 

