import { useState } from 'react';

const InputText = (props) => {
    const [value, setValue] = useState('');
    return (
        <>
            <label>Add Item Here:</label>
            <form onSubmit={(e) => {
                e.preventDefault();
                props.handleSubmit(value);
                setValue('');
            }}>
                <input type="text" value={value} onChange={e =>
                    setValue(e.target.value)} />
            </form>
        </>
    )
}

export default InputText;