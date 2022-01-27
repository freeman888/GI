namespace GTXAM.GasControl.Control
{
    interface ISetter
    {
        void ISetWidth(object value);
        void ISetHeight(object value);
        void ISetHorizontalAlignment(object value);
        void ISetVerticalAlignment(object value);
        void ISetMarin(object value);
        void ISetVisibility(object value);
        void ISetText(object value);
        void ISetFontSize(object value);
        void ISetPadding(object value);
        void ISetBackgroundColor(object value);
        void ISetForegroundColor(object value);
        void ISetTogged(object value);
        void ISetScrollPosition(object value);

        void ISetClickEvent(object value);

    }
}
