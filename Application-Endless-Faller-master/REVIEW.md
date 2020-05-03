# Project Review

## Applicant name

---

<!-- Your review goes here -->
I never had such a nice project for an application process. As a game design nerd, I tried to make the game feel as nice as possible. I tried so by adding some squash and stretch to the player model, simple particles and
a warm and a cold Light(because everybody finds this combination to be appealing).

<!-- Explain why you did the things that way or any snippet that is word mentioning -->

<!--I had some issues with the UT Framework. I've never tried it before and hadn't had the time to give it a closer look during this project, I've looked up a few blogs and tutorials about it and were able to do a very small test about the player's position. Anyway, it is worth to dive into it in a more detailed way.-->

public class Test01
    {
        private GameObject player;
        private Vector3 cameraFake = new Vector3(0,0,-9);
        [UnityTest]
        public IEnumerator Test01WithEnumeratorPasses()
        {
            //load player Prefab
            GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
            //Set its position
            player.transform.position = new Vector3(0, 0, 0);
            //Check if the Z position is eaqual to zero.
            Assert.That(player.transform.position.z == 0);
            //Update position
            player.gameObject.transform.position = new Vector3(1000, 1000, 1);
            //check if the Z position is not eaqual to zero
            Assert.That(player.transform.position.z != 0);
            yield return null;
        }
    }

<!--Here I calculate the ratio between the speed of the platforms and the spawn rate. So that I can easily higher the speed and have a fitting spawn rate.-->

    ratio = Platform.speed / spawnPlatformPerSecond;
    timer = spawnPlatformPerSecond;
    CreatePlatform();

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 1 - (1 / spawnPlatformPerSecond))
        {
            CreatePlatform();
            spawnPlatformPerSecond += 0.01f;
            Platform.speed = spawnPlatformPerSecond * ratio;

            timer = 1;
        }
    }
    
   <!-- I included something which wasn't asked but annoyed me personally when I played through the game. sometimes the holes between the platforms where spawning underneath each other so that it was hard to not fall down the screen. Therefore i check the distance between the last spawned platforms x Pos and the newly generated x Pos and made sure that they aren't to close together. -->
void CreatePlatform()
    {    
    randomPos = Random.Range(-3.5f, 3.5f);
        float distance = Mathf.Abs(lastRanPos - randomPos);
        if (distance < 2)
        {
            CreatePlatform();
            return;

        }
        lastRanPos = randomPos;
        platformCount++;
        
 <!-- I've also made the ScoreManager public and static so that I can access him from anywhere in the game and always have the same results. I saved the high score to a .dat file.-->

<!-- If you had any issue and how you resolved them -->

<!-- I had some building issues in the end... I believe that some of them were intended. I found there some typos in the app bundle, an IL2CPP set as scripting Backend, low resolution set as standard. In the end, i didn't figure out how to get rid of the 4:3 aspect ratio. I tried my best to uncheck every option, which I thought that it could be the solution to this, but In the end, I just reset the whole player settings. Now that the project is done, I feel that this might not have been the best idea.-->
