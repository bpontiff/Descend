using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsHealthUI : MonoBehaviour
{
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
    [SerializeField]
    private AnimationClip heartFullClip;

    private List<HeartImage> heartImages;
    private HeartsHealthSystem heartsHealthSystem;

    private void Awake()
    {
        heartImages = new List<HeartImage>();
    }

    private void Start()
    {
        HeartsHealthSystem heartsHealthSystem = new HeartsHealthSystem(4);
        SetHeartsHealthSystem(heartsHealthSystem);
    }

    public void SetHeartsHealthSystem(HeartsHealthSystem heartsHealthSystem)
    {
        this.heartsHealthSystem = heartsHealthSystem;

        Vector2 heartAnchoredPosition = new Vector2(0, 0);
        foreach (HeartsHealthSystem.Heart heart in heartsHealthSystem.GetHearts())
        {
            CreateHeartImage(heartAnchoredPosition).SetHeartFragments(heart.GetFragments());
            heartAnchoredPosition += new Vector2(20, 0);
        }

        heartsHealthSystem.OnDamaged += HeartsHealthSystem_OnDamaged;
        heartsHealthSystem.OnHealed += HeartsHealthSystem_OnHealed;
        heartsHealthSystem.OnDead += HeartsHealthSystem_OnDead;
    }

    private void HeartsHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        // Hearts health system was damaged
        RefreshAllHearts();
    }

    private void HeartsHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        // Hearts health system was healed
        RefreshAllHearts();
        List<HeartsHealthSystem.Heart> hearts = heartsHealthSystem.GetHearts();
        for (int i = 0; i < heartImages.Count; i++)
        {
            HeartImage heartImage = heartImages[i];
            HeartsHealthSystem.Heart heart = hearts[i];
            Image currentHealth = heartImage.GetHeartImage();
            heartImage.SetHeartFragments(heart.GetFragments());
            if (heart.GetFragments() == HeartsHealthSystem.MAX_FRAGMENT_AMOUNT && currentHealth != heart4Sprite)
            {
                heartImage.PlayHeartFullAnimation();
            }
        }
    }

    private void HeartsHealthSystem_OnDead(object sender, System.EventArgs e)
    {
        // TODO: Do something here to show death
    }

    private void RefreshAllHearts()
    {
        List<HeartsHealthSystem.Heart> hearts = heartsHealthSystem.GetHearts();
        for (int i = 0; i < heartImages.Count; i++)
        {
            HeartImage heartImage = heartImages[i];
            HeartsHealthSystem.Heart heart = hearts[i];
            heartImage.SetHeartFragments(heart.GetFragments());
        }
    }

    private HeartImage CreateHeartImage(Vector2 anchoredPosition)
    {
        // Create Game Object
        GameObject heartGameObject = new GameObject("Heart", typeof(Image), typeof(Animation));
        // Set as child of this transform
        heartGameObject.transform.SetParent(transform);
        heartGameObject.transform.localPosition = Vector3.zero;

        // Locate and size heart
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(15, 15);

        heartGameObject.GetComponent<Animation>().AddClip(heartFullClip, "HeartFull");

        // Set heart sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heart4Sprite;

        HeartImage heartImage = new HeartImage(this, heartImageUI, heartGameObject.GetComponent<Animation>());
        heartImages.Add(heartImage);

        return heartImage;
    }

    // Represents a single heart
    public class HeartImage
    {
        private Image heartImage;
        private HeartsHealthUI heartsHealthUI;
        private Animation animation;

        public HeartImage(HeartsHealthUI heartsHealthUI, Image heartImage, Animation animation)
        {
            this.heartsHealthUI = heartsHealthUI;
            this.heartImage = heartImage;
            this.animation = animation;
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

        public void PlayHeartFullAnimation()
        {
            animation.Play("HeartFull", PlayMode.StopAll);
        }

    }
}
