namespace GTXAM.GasControl.Control
{
    interface IGetter
    {
        object IGetWidth();
        object IGetHeight();
        object IGetHorizontalAlignment();
        object IGetVerticalAlignment();
        object IGetMarin();
        object IGetVisibility();
        object IGetText();
        object IGetFontSize();
        object IGetPadding();
        object IGetBackgroundColor();
        object IGetForegroundColor();
        object IGetTogged();
        object IGetScrollPosition();

        object IFindID(string id);
    }
}
