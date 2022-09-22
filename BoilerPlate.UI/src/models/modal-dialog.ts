export interface ModalDialogInterface {
    name: string
    title: string
    message: string
    confirmButton: string
    rejectButton: string
    buttonColor: string
    checkboxText: string | undefined;
}

export class ModalDialog implements ModalDialogInterface {
    name: string
    title: string
    message: string
    confirmButton: string
    rejectButton: string
    buttonColor: string
    checkboxText: string | undefined;

    constructor(options?: {
        name: string
        title: string
        message: string
        confirmButton: string
        rejectButton: string
        buttonColor: string
    }, checkboxText?: string) {
        this.name = options?.name ?? ''
        this.title = options?.title ?? ''
        this.message = options?.message ?? ''
        this.confirmButton = options?.confirmButton ?? ''
        this.rejectButton = options?.rejectButton ?? ''
        this.buttonColor = options?.buttonColor ?? ''
        this.checkboxText = checkboxText
    }
}