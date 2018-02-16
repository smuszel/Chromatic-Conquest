using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

[AddComponentMenu("Custom/Button", 30)]
public class CustomButton : Selectable, IPointerClickHandler, ISubmitHandler//, IEventSystemHandler
{
    #region AddedBehaviour
    public SoundEffect soundEffect;

    [Scene("OnPress")]
    public int selectedScene;

    private void AddedPressBehaviour()
    {
        // soundEffect.Execute();
        SceneManager.LoadScene(selectedScene);
    }

    public override void OnPointerEnter(PointerEventData d)
    {
        base.OnPointerEnter(d);
        
        soundEffect.Execute();
    }
    #endregion

    #region TweakedDefualtBehaviour

    // [Serializable]
    // public class ButtonClickedEvent : UnityEvent
    // {
    // }

    // [FormerlySerializedAs("onClick")]
    // [SerializeField]
    // private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();

    // public ButtonClickedEvent onClick
    // {
    //     get
    //     {
    //         return this.m_OnClick;
    //     }
    //     set
    //     {
    //         this.m_OnClick = value;
    //     }
    // }


    protected CustomButton()
    {
    }

    private void Press()
    {
        if (this.IsActive() && this.IsInteractable())
        {
            UISystemProfilerApi.AddMarker("Button.onClick", this);
            AddedPressBehaviour();
            //this.m_OnClick.Invoke();
        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            this.Press();
        }
    }

    public virtual void OnSubmit(BaseEventData eventData)
    {
        this.Press();
        if (this.IsActive() && this.IsInteractable())
        {
            this.DoStateTransition(SelectionState.Pressed, false);
            base.StartCoroutine(this.OnFinishSubmit());
        }
    }

    private IEnumerator OnFinishSubmit()
    {
        float fadeTime = base.colors.fadeDuration;
        float elapsedTime = 0f;
        if (elapsedTime < fadeTime)
        {
            // float num = elapsedTime + Time.unscaledDeltaTime;
            yield return (object)null;
            /*Error: Unable to find new state assignment for yield return*/
            ;
        }
        this.DoStateTransition(base.currentSelectionState, false);
    }

    #endregion
}