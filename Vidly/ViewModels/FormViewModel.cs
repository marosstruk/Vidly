namespace Vidly.ViewModels
{
    public abstract class FormViewModel<T>
    {
        public string? Action { get; set; }

        public FormViewModel()
        {
        }

        public FormViewModel(string action, T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Action = action;

            var sourceProps = entity.GetType().GetProperties();
            var targetProps = this.GetType().GetProperties();
            var commonProps = from sp in sourceProps
                              join tp in targetProps
                                on sp.Name equals tp.Name
                              select new { sp, tp };

            foreach (var props in commonProps)
                props.tp.SetValue(this, props.sp.GetValue(entity));
        }
    }
}
