using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersListObject
{
	public enum Triggers //these are all the buttons that the XRI input system has to offer
	{
		None, 
		XRI_Left_Primary2DAxis_Vertical,
        XRI_Left_Primary2DAxis_Horizontal,
        XRI_Left_Secondary2DAxis_Vertical,
        XRI_Left_Secondary2DAxis_Horizontal,
        XRI_Left_Trigger,
        XRI_Left_Grip,
        XRI_Left_IndexTouch,
        XRI_Left_ThumbTouch,
        XRI_Left_PrimaryButton,
        XRI_Left_SecondaryButton,
        XRI_Left_PrimaryTouch,
        XRI_Left_SecondaryTouch,
        XRI_Left_GripButton,
        XRI_Left_TriggerButton,
        XRI_Left_MenuButton,
        XRI_Left_Primary2DAxisClick,
        XRI_Left_Primary2DAxisTouch,
        XRI_Left_Thumbrest,
        XRI_Right_Primary2DAxis_Vertical,
        XRI_Right_Primary2DAxis_Horizontal,
        XRI_Right_Secondary2DAxis_Vertical,
        XRI_Right_Secondary2DAxis_Horizontal,
        XRI_Right_Trigger,
        XRI_Right_Grip,
        XRI_Right_IndexTouch,
        XRI_Right_ThumbTouch,
        XRI_Right_PrimaryButton,
        XRI_Right_SecondaryButton,
        XRI_Right_PrimaryTouch,
        XRI_Right_SecondaryTouch,
        XRI_Right_GripButton,
        XRI_Right_TriggerButton,
        XRI_Right_MenuButton,
        XRI_Right_Primary2DAxisClick,
        XRI_Right_Primary2DAxisTouch,
        XRI_Right_Thumbrest,
        XRI_Combined_Trigger,
        XRI_DPad_Vertical,
        XRI_DPad_Horizontal
    }
}
