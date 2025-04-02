namespace Behaviours
{
    internal interface ILevelLoader
    {
        void LoadLevelByIndex(int index);
        void ClearLevelFull();
        bool LoadNextLevel();
        void ResetLevels();
        bool IsLastLevel();
    }
}
