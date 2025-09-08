using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    public GameObject playerPrefab;
    public Transform playerTransform;
    public Vector3 initialPosition;

    [SetUp]
    public void Setup()
    {
        playerPrefab = Resources.Load<GameObject>("Player");

        var playerInstance = Object.Instantiate(playerPrefab);

        playerTransform = playerInstance.GetComponent<Transform>();

        initialPosition = playerTransform.position;
    }

    [TearDown]
    public void Teardown()
    {
        if (playerPrefab != null && GameObject.Find("Player(Clone)") != null)
            Object.DestroyImmediate(GameObject.Find("Player(Clone)"));
    }

    [UnityTest]
    public IEnumerator MoveForward()
    {
        yield return new WaitForSeconds(1); 

        Assert.AreNotEqual(initialPosition, playerTransform.position,
                          "Игрок не переместился вперед!");
    }

    [UnityTest]
    public IEnumerator RotateRight()
    {
        playerTransform.SendMessage("RotateRight"); 

        yield return new WaitForSeconds(1); 

        Assert.AreNotEqual(initialPosition.x, playerTransform.position.x,
                          "Игрок не повернулся вправо!");
    }
}
