using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewModel.Extensions
{
    public static class TopLeftVeiwModelExtenstion
    {
        public static void RefeshViewModel(this TopLeftVViewModel vm)
        {
            int tempId = 2;
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewMode);
        }

        public static void OnRefreshViewMode(this TopLeftVViewModel vm, int userId, string name, int level)
        {
            vm.UserId = userId;
            vm.Name = name;
            vm.Level = level;
        }

        //public static void RegisterEventOnEnable(this TopLeftVViewModel vm) 
        //{
        //    if (isRegstring)
        //    { 
        //        GameLogicManager.Inst
        //    }
        //}

        public static void RegisterEnvetOnEnable(this TopLeftVViewModel vm)
        {
            GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
        }

        public static void UnRegisterEnvetOnDisable(this TopLeftVViewModel vm)
        {
            GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);

        }

        public static void OnResponseLevelUp(this TopLeftVViewModel vm, int userId, int level)
        {
            if (vm.UserId != userId)
                return;

            vm.Level = level;
        }

    }

}

