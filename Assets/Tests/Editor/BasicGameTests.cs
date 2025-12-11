using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using UnityEngine;
using NUnit.Framework;

public class BasicGameTests
{
    private ScoreManager scoreManager;
    private PlayerHealthManager healthManager;

    [SetUp]
    public void Setup()
    {
        scoreManager = new GameObject().AddComponent<ScoreManager>();
        healthManager = new GameObject().AddComponent<PlayerHealthManager>();

        ScoreManager.Instance = scoreManager;
        PlayerHealthManager.Instance = healthManager;
    }

    [Test]
    public void PlayerHealthManager_ChangeHealth_ModifiesHealth()
    {
        float test = healthManager.GetHealth() - 1;
        Assert.AreEqual(test, -1);
    }

    [Test]
    public void PlayerHealthManager_HealthDoesNotExceedMax()
    {
        healthManager.ChangeHealth(100);
        Assert.AreEqual(healthManager.GetHealth(), 100);
    }

    [Test]
    public void ScoreManager_AddMultipleScores()
    {
        scoreManager.AddScore(3);
        scoreManager.AddScore(7);
        Assert.AreEqual(10, scoreManager.GetScore());
    }
}

