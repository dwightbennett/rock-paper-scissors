using RockPaperScissors.Data;
using Xamarin.Forms;

namespace RockPaperScissors.Behaviors
{
    public class SelectedBehavior : Behavior<Button>
    {
        private readonly Color SelectedColor = Color.DarkBlue;
        private readonly Color UnSelectedColor = Color.DeepSkyBlue;
        private Button selectionButton;

        public Selection Selection
        {
            get => (Selection)GetValue(SelectionProperty);
            set => SetValue(SelectionProperty, value);
        }

        public static readonly BindableProperty SelectionProperty = BindableProperty.Create(nameof(Selection),
            typeof(Selection), typeof(SelectedBehavior), Selection.None);

        public Selection PlayerSelection
        {
            get => (Selection)GetValue(PlayerSelectionProperty);
            set => SetValue(PlayerSelectionProperty, value);
        }

        public static readonly BindableProperty PlayerSelectionProperty = BindableProperty.Create(nameof(PlayerSelection),
            typeof(Selection), typeof(SelectedBehavior), Selection.None, propertyChanged: playerSelectionChanged);
        
    

        private static void playerSelectionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is SelectedBehavior behavior)
            {
                behavior.selectionButton.BackgroundColor = (Selection) newValue != behavior.Selection
                    ? behavior.UnSelectedColor
                    : behavior.SelectedColor;
            }
        }

        protected override void OnAttachedTo(Button bindable)
        {
            base.OnAttachedTo(bindable);
            selectionButton = bindable;
            bindable.BindingContextChanged += Bindable_BindingContextChanged; 
        }

        protected override void OnDetachingFrom(Button bindable)
        {
            bindable.BindingContextChanged -= Bindable_BindingContextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void Bindable_BindingContextChanged(object sender, System.EventArgs e)
        {
            BindingContext = selectionButton.BindingContext;
        }
    }
}
