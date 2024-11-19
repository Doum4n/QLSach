namespace QLSach.components
{
    public class RegisterHelper
    {
        public BindingSource registration_data { get; set; }
        public BindingSource borrowed_data { get; set; }

        public RegisterHelper()
        {
            registration_data = new BindingSource();
            borrowed_data = new BindingSource();
        }
    }
}
