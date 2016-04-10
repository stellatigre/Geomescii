using System;

namespace MIDI
{
    class HardwareControlMapping: Attribute{};
    class SliderAttribute: Attribute {};
    class KnobAttribute: Attribute {};
    class SoloAttribute: Attribute {};
    class MuteAttribute: Attribute {};
    class RetriggerAttribute: Attribute {};

    [HardwareControlMapping]
    public enum NanoKontrol2
    {
        [Slider]    sliderOne = 0,
        [Knob]      knobOne = 16,
        [Solo]      soloOne = 32,
        [Mute]      muteOne = 48,
        [Retrigger] retriggerOne = 64,

        [Slider]    sliderTwo = 1,
        [Knob]      knobTwo = 17,
        [Solo]      soloTwo = 33,
        [Mute]      muteTwo = 49,
        [Retrigger] retriggerTwo = 65,

        [Slider]    sliderThree = 2,
        [Knob]      knobThree = 18,
        [Solo]      soloThree = 34,
        [Mute]      muteThree = 50,
        [Retrigger] retriggerThree = 66,

        [Slider]    sliderFour = 3,
        [Knob]      knobFour = 19,
        [Solo]      soloFour = 35,
        [Mute]      muteFour = 51,
        [Retrigger] retriggerFour = 67,

        [Slider]    sliderFive = 4,
        [Knob]      knobFive = 20,
        [Solo]      soloFive = 36,
        [Mute]      muteFive = 52,
        [Retrigger] retriggerFive = 68,

        [Slider]    sliderSix = 5,
        [Knob]      knobSix = 21,
        [Solo]      soloSix = 37,
        [Mute]      muteSix = 53,
        [Retrigger] retriggerSix = 69,

        [Slider]    sliderSeven = 6,
        [Knob]      knobSeven = 22,
        [Solo]      soloSeven = 38,
        [Mute]      muteSeven = 54,
        [Retrigger] retriggerSeven = 70,

        [Slider]    sliderEight = 7,
        [Knob]      knobEight = 23,
        [Solo]      soloEight = 39,
        [Mute]      muteEight = 55,
        [Retrigger] retriggerEight = 71,
    }
}

