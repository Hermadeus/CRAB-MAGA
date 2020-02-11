using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    public interface IUITilable
    {
        void OnClick();
    }
    public interface IUIMenu
    {

        void OnOpen();

        void OnClose();
    }
}
