using Assets.Public.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsHealthUI : MonoBehaviour
{
    [SerializeField]
    private float screenSizePercent;
    [SerializeField]
    private Sprite heart0Sprite;
    [SerializeField]
    private Sprite heart1Sprite;
    [SerializeField]
    private Sprite heart2Sprite;
    [SerializeField]
    private Sprite heart3Sprite;
    [SerializeField]
    private Sprite heart4Sprite;

    private List<HeartImage> heartImages;

    public int playerNum;
    private Player player;

    private HeartsHealthSystem heartsHealthSystem;

    private void Awake()
    {
        heartImages = new List<HeartImage>();
    }

    private void Start()
    {
        player = GameObject.Find("Player" + (playerNum + 1)).GetComponent<Player>();

        HeartsHealthSystem heartsHealthSystem = new HeartsHealthSystem(player.maxHealth);
        SetHeartsHealthSystem(heartsHealthSystem);
    }

    private void Update()
    {


        Debug.Log(GetComponentInParent<Canvas>().worldCamera.scaledPixelWidth);
    }

    public void SetHeartsHealthSystem(HeartsHealthSystem heartsHealthSystem)
    {
        this.heartsHealthSystem = heartsHealthSystem;
        this.player.SetHeartsHealthSystem(heartsHealthSystem);

        Vector2 heartAnchoredPosition = new Vector2(0, 0);
        foreach (HeartsHealthSystem.Heart heart in heartsHealthSystem.GetHearts())
        {
            CreateHeartImage(heartAnchoredPosition).SetHeartFragments(heart.GetFragments());
            float pixelWidth = GetComponentInParent<Canvas>().worldCamera.scaledPixelWidth;
            float size = pixelWidth * (screenSizePercent / 2);
            heartAnchoredPosition += new Vector2(size, 0);
        }

        heartsHealthSystem.OnDamaged += HeartsHealthSystem_OnDamaged;
        heartsHealthSystem.OnHealed += HeartsHealthSystem_OnHealed;
        heartsHealthSystem.OnDead += HeartsHealthSystem_OnDead;
    }

    private void HeartsHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        // Hearts health system was damaged
        refreshHearts(sender);
    }

    private void HeartsHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        // Hearts health system was healed
        refreshHearts(sender);
    }

    private void HeartsHealthSystem_OnDead(object sender, System.EventArgs e)
    {
        // TODO: Do something here to show death
    }

    private void refreshHearts(object sender)
    {
        if (sender == this.heartsHealthSystem)
        {
            List<HeartsHealthSystem.Heart> hearts = heartsHealthSystem.GetHearts();
            for (int i = 0; i < heartImages.Count; i++)
            {
                HeartImage heartImage = heartImages[i];
                HeartsHealthSystem.Heart heart = hearts[i];
                heartImage.SetHeartFragments(heart.GetFragments());
            }
        }
    }

    private HeartImage CreateHeartImage(Vector2 anchoredPosition)
    {
        // Create Game Object
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));
        // Set as child of this transform
        heartGameObject.transform.SetParent(transform);
        heartGameObject.transform.localPosition = Vector3.zero;
        float pixelWidth = GetComponentInParent<Canvas>().worldCamera.scaledPixelWidth;
        float size = pixelWidth * (screenSizePercent / 100);
        // Locate and size heart
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);


        // Set heart sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heart4Sprite;

        HeartImage heartImage = new HeartImage(this, heartImageUI);
        heartImages.Add(heartImage);

        return heartImage;
    }

    // Represents a single heart
    public class HeartImage
    {
        private Image heartImage;
        private HeartsHealthUI heartsHealthUI;

        public HeartImage(HeartsHealthUI heartsHealthUI, Image heartImage)
        {
            this.heartsHealthUI = heartsHealthUI;
            this.heartImage = heartImage;
        }

        public Image GetHeartImage()
        {
            return this.heartImage;
        }

        public void SetHeartFragments(int fragments)
        {
            switch(fragments)
            {
                case 0: heartImage.sprite = heartsHealthUI.heart0Sprite; break;
                case 1: heartImage.sprite = heartsHealthUI.heart1Sprite; break;
                case 2: heartImage.sprite = heartsHealthUI.heart2Sprite; break;
                case 3: heartImage.sprite = heartsHealthUI.heart3Sprite; break;
                case 4: heartImage.sprite = heartsHealthUI.heart4Sprite; break;
            }
        }

    }
}
