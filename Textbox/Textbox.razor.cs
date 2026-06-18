using BootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System.Text.RegularExpressions;

namespace BootstrapComponents.Textbox;

public partial class TextBox
{
    /// <summary>
    /// InputType is type of input supports only text, password, email 
    /// </summary>
    [Parameter] public InputType InputType { get; set; } = InputType.Text;

    /// <summary>
    /// Label of the textbox
    /// </summary>
    [Parameter] public string? Label { get; set; }

    [Parameter] public string? Placeholder { get; set; }
    /// <summary>
    /// Label Position is where do you want textbox label around the textbox
    /// </summary>
    [Parameter] public LabelPosition LabelPosition { get; set; } = LabelPosition.Floating;

    [Parameter] public bool ShowValidationMessage { get; set; } = true;

    [Parameter] public string? CssClass { get; set; }

    /// <summary>
    /// Show strenght of the password this is only use for input type password
    /// </summary>
    [Parameter] public bool ShowStrength { get; set; }

    /// <summary>
    /// Toggle password from hidden to text
    /// </summary>
    [Parameter] public bool AllowTogglePassword { get; set; } = true;

    [Parameter] public EventCallback<ChangeEventArgs> OnInput { get; set; }

    [Parameter] public EventCallback<ChangeEventArgs> OnChange { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    public enum PasswordStrength
    {
        None,
        Weak,
        Medium,
        Strong
    }
    private bool showPassword;
    protected PasswordStrength Strength =>
    GetPasswordStrength(CurrentValue);
    private InputType CurrentInputType => InputType.Equals(InputType.Password, StringComparison.OrdinalIgnoreCase)
            ? (showPassword ? InputType.Text : InputType.Password)
            : InputType.Text;

    protected string InputId =>
        $"txt_{FieldIdentifier.FieldName}";

    protected string PlaceholderText =>
        Placeholder ?? Label ?? string.Empty;

    protected string InputCssClass =>
        $"form-control {CssClass} {EditContext?.FieldCssClass(FieldIdentifier)}";

    protected override bool TryParseValueFromString(
        string? value,
        out string? result,
        out string? validationErrorMessage)
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }

    private async Task HandleInput(ChangeEventArgs e)
    {
        CurrentValue = e.Value?.ToString();

        if (OnInput.HasDelegate)
            await OnInput.InvokeAsync(e);
    }
    private async Task HandleClick(MouseEventArgs e)
    {
        if (OnClick.HasDelegate)
        {
            await OnClick.InvokeAsync(e);
        }
    }
    private async Task HandleChange(ChangeEventArgs e)
    {
        CurrentValue = e.Value?.ToString();

        if (OnChange.HasDelegate)
        {
            await OnChange.InvokeAsync(e);
        }
    }
    private PasswordStrength GetPasswordStrength(string? password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return PasswordStrength.None;

        int score = 0;

        if (Regex.IsMatch(password, "[a-z]"))
            score++;

        if (Regex.IsMatch(password, "[A-Z]"))
            score++;

        if (Regex.IsMatch(password, "[0-9]"))
            score++;

        if (Regex.IsMatch(password, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
            score++;

        if (password.Length >= 8)
            score++;

        return score switch
        {
            <= 2 => PasswordStrength.Weak,
            <= 4 => PasswordStrength.Medium,
            _ => PasswordStrength.Strong
        };
    }
    private void TogglePassword()
    {
        showPassword = !showPassword;
    }
}