import { InputText } from "./style"

export const Input = ({
    placeholder,
    editable = false,
    fieldValue = null,
    onChangeText = null,
    keyType,
    maxLength
}) => {
    return (
        <InputText
            placeholder={placeholder}
            editable={editable}
            keyBoardType={keyType}
            maxLength={maxLength}
            value={fieldValue}
            onChangeText={onChangeText}
        />
    )
}