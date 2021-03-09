using System;

namespace View.Abstractions.PresentersAbstractions
{
    public interface IOrderInfoPresenter : IPresenter
    {
        void GetOrderProcessTimeBtnClicked(object sender, EventArgs args);
    }
}