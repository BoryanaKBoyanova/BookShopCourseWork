namespace BookShopCourseWork.Models.Enums
{
    using System.ComponentModel;
    public enum OrderStatus
    {
        [Description("Sent")]
        SENT,

        [Description("Processing")]
        PROCESSING,

        [Description("Cancelled")]
        CANCELLED,

        [Description("Delivered")]
        DELIVERED
        
    }
}