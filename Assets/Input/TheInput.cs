// GENERATED AUTOMATICALLY FROM 'Assets/Input/TheInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TheInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TheInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TheInput"",
    ""maps"": [
        {
            ""name"": ""Rafa"",
            ""id"": ""ed49bc1a-8f16-47ea-8431-bb2503582263"",
            ""actions"": [
                {
                    ""name"": ""Talk"",
                    ""type"": ""Button"",
                    ""id"": ""5e61c13d-4ab0-4d15-b092-477e6447e839"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchHand"",
                    ""type"": ""Button"",
                    ""id"": ""90fdc264-31d8-4e57-ab68-b24861c1aee1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""acd39d58-bced-4e28-9fa7-efda4e80edb4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Value"",
                    ""id"": ""1bb876e7-2cc4-49c4-866b-56846402aff8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveHand"",
                    ""type"": ""Value"",
                    ""id"": ""315663a8-5c9d-4fd2-8721-cf5871bbe39e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""48ded9a3-8f1c-4b3c-b47d-7aad93593034"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Duck"",
                    ""type"": ""Button"",
                    ""id"": ""99416f07-ae57-46d3-b5be-b2fdf71633ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseHand"",
                    ""type"": ""Value"",
                    ""id"": ""0134eac2-f25e-4d0d-bfd8-298694faf9f2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoystickHandDetector"",
                    ""type"": ""Value"",
                    ""id"": ""4f43aa1c-9ebf-42de-ae19-011d6e5fad4e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseHandDetector"",
                    ""type"": ""Value"",
                    ""id"": ""5dd9720c-5efe-4dd2-b085-46cee6615a83"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""c5b37711-e6f8-48c1-90cd-a0c24780202a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""1f228859-1e39-4804-9a52-e7f440869fd2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""17401e10-5964-4deb-9a7d-b62d3b01fd37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""92dee949-3572-493c-bed6-c56f05b6a1ba"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Talk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""434aa83a-3625-40fe-b60b-6d20c8d17ba2"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Talk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e66ca36b-c8f3-4922-a185-e612615458e5"",
                    ""path"": ""<HID::54C-5C4>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Talk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fac3d731-182d-4521-9a4e-79e1622dda03"",
                    ""path"": ""<HID::54C-5C4>/button12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80de5556-7d18-4314-80ae-a74fe0306dee"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49a4df7d-c5be-454b-97c6-89525d058118"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06a80488-191c-4af7-a086-04eb90e4214f"",
                    ""path"": ""<HID::54C-5C4>/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91d582e8-f77c-4a1c-9a95-d803c5997c10"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6407e1a4-7635-4fb8-a36a-63510df2592f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bc0322b-688c-4c0c-a1db-6154d67325fc"",
                    ""path"": ""<HID::54C-5C4>/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6872a658-5e4b-43cd-a621-1ae9b67ba158"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63311deb-b100-4f28-8b8a-cbf87fdf672b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""651d8252-9a0f-4db3-8d4e-dd68ae95494e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""44ffc156-307a-45c7-aa9b-10f6205c795a"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHand"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8e77c8ad-9d8e-45f9-b24e-b1f7e70afa7f"",
                    ""path"": ""<Joystick>/R"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c311ee88-2294-4deb-beae-411185b0025f"",
                    ""path"": ""<Joystick>/Rz"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ec2b2994-2f58-4e18-bc0d-498e92739f06"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e82fedcb-3be3-4f55-bab2-81e4c4ee1c3a"",
                    ""path"": ""<Joystick>/Z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cc8bae58-bf82-48ea-ac32-ee18f3286c64"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9fbdde0-0b52-4ce5-b73c-211f8822b539"",
                    ""path"": ""<HID::54C-5C4>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8e4a8d8-ad49-4c73-a0c0-709035450231"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b2ff47f9-ee26-4b40-9193-3963cabfd13d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ef05ea7f-c258-4123-bdf4-d35bd4d81bc4"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5063895b-527d-44d7-9796-77e861c0df02"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a21f75b8-56a4-479a-a444-21e922074567"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4766fc69-6aed-414e-8704-0ee879b76a0a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""d84727f6-6ec3-4210-9111-bba26af75ece"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""468cbbf3-721f-470c-b838-913fcc6cbbd1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fb9e1af7-c3ca-4c62-a74e-c12591983e41"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0dccbd9a-c332-4490-a264-87fafbbe5262"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""516e5a18-032b-43df-963a-f49e76ef7591"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""92dc5d0a-ccf1-4201-87fd-63e42f1de624"",
                    ""path"": ""<HID::54C-5C4>/button11"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddbfcd84-e5fe-4724-a546-4143fa46d0bf"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3099f55f-ce76-4284-a0a1-a23c0e77a937"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""733b41ee-1c1b-44b1-8368-0f98c85c6998"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c73bf59-8116-4f13-805c-ac5c09670eff"",
                    ""path"": ""<HID::54C-5C4>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""018d9000-bbcd-4d49-8de8-5faa8bccd175"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd641134-fe93-4c93-8a9e-39d610fc89d2"",
                    ""path"": ""<HID::54C-5C4>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickHandDetector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30147aa7-5c09-407f-8397-689c8fef5c22"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickHandDetector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cf49b1a8-5f61-46fe-8a5e-038eac7c6b24"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickHandDetector"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0e784558-98d8-4ea7-929d-520b7f48fdf0"",
                    ""path"": ""<Joystick>/R"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickHandDetector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fe02bafd-75d0-4444-b5f4-01bbb20e3cbf"",
                    ""path"": ""<Joystick>/Rz"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickHandDetector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b55f5b73-bcb6-4a6c-96d9-185a8b4c0398"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickHandDetector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c9ada265-0c5e-435f-b2d8-f53ea7a5bd4d"",
                    ""path"": ""<Joystick>/Z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickHandDetector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4ecdde21-48fe-4dd5-976d-78931aeb4de2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickHandDetector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7079bfcc-2fe0-4abb-8941-daa51baac868"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseHandDetector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e64dc86-b6fb-4899-b432-a87c497eccde"",
                    ""path"": ""<HID::54C-5C4>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71a8fee1-1789-495c-bac8-bf3051e136de"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04bd2136-5314-4b32-b528-1956a2fe664f"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94560df4-de01-4c62-a951-235d7fa3fef9"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3f18f95-1eef-4d5b-8689-f076a5a1347f"",
                    ""path"": ""<HID::54C-5C4>/button10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b970d5d-c234-4e57-a12b-b65b417d8958"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74a0661a-a430-48e3-9d20-9443ce219d9c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e588a052-6dc4-4c19-b58f-f8d42cb518fc"",
                    ""path"": ""<HID::54C-5C4>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9006f0bb-7cd6-4898-a106-b4035a87e7fb"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Rafa
        m_Rafa = asset.FindActionMap("Rafa", throwIfNotFound: true);
        m_Rafa_Talk = m_Rafa.FindAction("Talk", throwIfNotFound: true);
        m_Rafa_SwitchHand = m_Rafa.FindAction("SwitchHand", throwIfNotFound: true);
        m_Rafa_Grab = m_Rafa.FindAction("Grab", throwIfNotFound: true);
        m_Rafa_Use = m_Rafa.FindAction("Use", throwIfNotFound: true);
        m_Rafa_MoveHand = m_Rafa.FindAction("MoveHand", throwIfNotFound: true);
        m_Rafa_Walk = m_Rafa.FindAction("Walk", throwIfNotFound: true);
        m_Rafa_Duck = m_Rafa.FindAction("Duck", throwIfNotFound: true);
        m_Rafa_MouseHand = m_Rafa.FindAction("MouseHand", throwIfNotFound: true);
        m_Rafa_JoystickHandDetector = m_Rafa.FindAction("JoystickHandDetector", throwIfNotFound: true);
        m_Rafa_MouseHandDetector = m_Rafa.FindAction("MouseHandDetector", throwIfNotFound: true);
        m_Rafa_Interact = m_Rafa.FindAction("Interact", throwIfNotFound: true);
        m_Rafa_Restart = m_Rafa.FindAction("Restart", throwIfNotFound: true);
        m_Rafa_Cancel = m_Rafa.FindAction("Cancel", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Rafa
    private readonly InputActionMap m_Rafa;
    private IRafaActions m_RafaActionsCallbackInterface;
    private readonly InputAction m_Rafa_Talk;
    private readonly InputAction m_Rafa_SwitchHand;
    private readonly InputAction m_Rafa_Grab;
    private readonly InputAction m_Rafa_Use;
    private readonly InputAction m_Rafa_MoveHand;
    private readonly InputAction m_Rafa_Walk;
    private readonly InputAction m_Rafa_Duck;
    private readonly InputAction m_Rafa_MouseHand;
    private readonly InputAction m_Rafa_JoystickHandDetector;
    private readonly InputAction m_Rafa_MouseHandDetector;
    private readonly InputAction m_Rafa_Interact;
    private readonly InputAction m_Rafa_Restart;
    private readonly InputAction m_Rafa_Cancel;
    public struct RafaActions
    {
        private @TheInput m_Wrapper;
        public RafaActions(@TheInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Talk => m_Wrapper.m_Rafa_Talk;
        public InputAction @SwitchHand => m_Wrapper.m_Rafa_SwitchHand;
        public InputAction @Grab => m_Wrapper.m_Rafa_Grab;
        public InputAction @Use => m_Wrapper.m_Rafa_Use;
        public InputAction @MoveHand => m_Wrapper.m_Rafa_MoveHand;
        public InputAction @Walk => m_Wrapper.m_Rafa_Walk;
        public InputAction @Duck => m_Wrapper.m_Rafa_Duck;
        public InputAction @MouseHand => m_Wrapper.m_Rafa_MouseHand;
        public InputAction @JoystickHandDetector => m_Wrapper.m_Rafa_JoystickHandDetector;
        public InputAction @MouseHandDetector => m_Wrapper.m_Rafa_MouseHandDetector;
        public InputAction @Interact => m_Wrapper.m_Rafa_Interact;
        public InputAction @Restart => m_Wrapper.m_Rafa_Restart;
        public InputAction @Cancel => m_Wrapper.m_Rafa_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_Rafa; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RafaActions set) { return set.Get(); }
        public void SetCallbacks(IRafaActions instance)
        {
            if (m_Wrapper.m_RafaActionsCallbackInterface != null)
            {
                @Talk.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnTalk;
                @Talk.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnTalk;
                @Talk.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnTalk;
                @SwitchHand.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnSwitchHand;
                @SwitchHand.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnSwitchHand;
                @SwitchHand.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnSwitchHand;
                @Grab.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnGrab;
                @Use.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnUse;
                @MoveHand.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnMoveHand;
                @MoveHand.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnMoveHand;
                @MoveHand.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnMoveHand;
                @Walk.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnWalk;
                @Duck.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnDuck;
                @Duck.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnDuck;
                @Duck.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnDuck;
                @MouseHand.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnMouseHand;
                @MouseHand.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnMouseHand;
                @MouseHand.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnMouseHand;
                @JoystickHandDetector.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnJoystickHandDetector;
                @JoystickHandDetector.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnJoystickHandDetector;
                @JoystickHandDetector.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnJoystickHandDetector;
                @MouseHandDetector.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnMouseHandDetector;
                @MouseHandDetector.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnMouseHandDetector;
                @MouseHandDetector.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnMouseHandDetector;
                @Interact.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnInteract;
                @Restart.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnRestart;
                @Cancel.started -= m_Wrapper.m_RafaActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_RafaActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_RafaActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_RafaActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Talk.started += instance.OnTalk;
                @Talk.performed += instance.OnTalk;
                @Talk.canceled += instance.OnTalk;
                @SwitchHand.started += instance.OnSwitchHand;
                @SwitchHand.performed += instance.OnSwitchHand;
                @SwitchHand.canceled += instance.OnSwitchHand;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @MoveHand.started += instance.OnMoveHand;
                @MoveHand.performed += instance.OnMoveHand;
                @MoveHand.canceled += instance.OnMoveHand;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Duck.started += instance.OnDuck;
                @Duck.performed += instance.OnDuck;
                @Duck.canceled += instance.OnDuck;
                @MouseHand.started += instance.OnMouseHand;
                @MouseHand.performed += instance.OnMouseHand;
                @MouseHand.canceled += instance.OnMouseHand;
                @JoystickHandDetector.started += instance.OnJoystickHandDetector;
                @JoystickHandDetector.performed += instance.OnJoystickHandDetector;
                @JoystickHandDetector.canceled += instance.OnJoystickHandDetector;
                @MouseHandDetector.started += instance.OnMouseHandDetector;
                @MouseHandDetector.performed += instance.OnMouseHandDetector;
                @MouseHandDetector.canceled += instance.OnMouseHandDetector;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public RafaActions @Rafa => new RafaActions(this);
    public interface IRafaActions
    {
        void OnTalk(InputAction.CallbackContext context);
        void OnSwitchHand(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnMoveHand(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnDuck(InputAction.CallbackContext context);
        void OnMouseHand(InputAction.CallbackContext context);
        void OnJoystickHandDetector(InputAction.CallbackContext context);
        void OnMouseHandDetector(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
}
