namespace GTWPF.GasControl.Control
{
    interface IGetter
    {
        object IGetWidth();
        object IGetHeight();
        object IGetHorizontalAlignment();
        object IGetVerticalAlignment();
        object IGetMargin();
        object IGetVisibility();
        object IGetText();
        object IGetFontSize();
        object IGetPadding();
        object IGetBackgroundColor();
        object IGetForegroundColor();
        object IGetScrollPosition();
        object IGetTogged();

        object IFindID(string id);
    }
}
