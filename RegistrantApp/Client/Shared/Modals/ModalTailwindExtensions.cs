using System.ComponentModel;
using Microsoft.AspNetCore.Components;

namespace RegistrantApp.Client.Shared.Modals;

public class ModalTailwindExtensions : ComponentBase
{
    protected ModalState _stateModal = ModalState.Closed;

    protected CancellationToken _cancellationToken;

    protected string _optionTitleWindows = "Модальное окно";
    
    protected string _optionBlurBackground = _constBackDrop;
    protected string _optionBackgroundLayerState = _constBackgroundStateClose;
    protected string _optionModalLayerState = _constModalStateClose;


    private const string _constBackgroundStateClose = "ease-in duration-100 opacity-0";
    private const string _constModalStateClose =
        "ease-in duration-100 opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95";

    private const string _constBackgroundStateOpen = "ease-out duration-100 opacity-100";
    private const string _constModalStateOpen = "ease-out duration-100 opacity-100 translate-y-0 sm:scale-100";

    private const string _constBackDrop = "backdrop-blur-md";
    
    private const int _constDelay = 300;

    protected async void ModalStateChangeAsync(ModalState newState)
    {
        // ппц костыль но что поделать
        if (newState == ModalState.Open)
        {
            _stateModal = newState;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(_constDelay);
        }
        
        switch (newState)
        {
            case ModalState.Closed:
                _optionBackgroundLayerState = _constBackgroundStateClose;
                _optionModalLayerState = _constModalStateClose;
                break;
            case ModalState.Open:
                _optionBackgroundLayerState = _constBackgroundStateOpen;
                _optionModalLayerState = _constModalStateOpen;
                break;
        }

        await InvokeAsync(StateHasChanged);
        
        if(newState == ModalState.Closed)
        {
            await Task.Delay(_constDelay);
            await InvokeAsync(StateHasChanged);
            _stateModal = newState;
            await Task.Delay(_constDelay);
            await InvokeAsync(StateHasChanged);
        }
    }
}

public enum ModalState
{
    Open,
    Closed
}