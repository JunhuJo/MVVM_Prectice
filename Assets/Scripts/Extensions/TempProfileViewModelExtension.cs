using ViewModel.Extensions;

namespace tempViewModelName.Extensions
{
    public static class TempProfileViewModelExtension
    {
        public static void RefeshViewModel(this TempProfileViewModel vm)
        {
            int tempId = 2;
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewMode);
        }
    
        public static void OnRefreshViewMode(this TempProfileViewModel vm, int userId, string name, int level)
        {
            vm.Name = name;
        }
    
        public static void RegisterEnvetOnEnable(this TempProfileViewModel vm)
        {
            GameLogicManager.Inst.RegisterReNameCallback(vm.OnResponsReName);
        }
    
        public static void UnRegisterEnvetOnDisable(this TempProfileViewModel vm)
        {
            GameLogicManager.Inst.UnRegisterReNameCallback(vm.OnResponsReName);
        }
        //
        public static void OnResponsReName(this TempProfileViewModel vm, int userId, string Name)
        {
            if (vm.UserId != userId)
                return;
            
            vm.Name = Name;
        }
    }
}


