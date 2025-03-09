using System;

public class ProgressMonitor
{
    private readonly GridMatchFinder _matchFinder;
    private readonly ISwitchableElement _loseScreen;

    public ProgressMonitor(GridMatchFinder matchFinder, ISwitchableElement loseScreen)
    {
        _matchFinder = matchFinder != null ? matchFinder : throw new ArgumentNullException(nameof(matchFinder));
        _loseScreen = loseScreen != null ? loseScreen : throw new ArgumentNullException(nameof(loseScreen));

        _matchFinder.GridBecameFull += OnGridFull;
    }

    ~ProgressMonitor()
    {
        _matchFinder.GridBecameFull -= OnGridFull;
    }

    private void OnGridFull()
    {
        _loseScreen.Enable();
    }
}