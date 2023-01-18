//import emailjs, { EmailJSResponseStatus } from 'emailjs-com';
import React, { useState } from 'react'

function Email() {
    const [value, setValue] = useState('Select Email Template');
    // const [TemplateSelected,setTemplateSelected] =useState('');
    const handleChanged = (event) => {
        setValue(event.target.value);
    }
    const CommentChangeHandler = (event) => {

    }
    const SenderEmailChangeHandler = (event) => {

    }
    const RecipientEmailChangeHandler = (event) => {

    }
    const RecipientNameChangeHandler = (event) => {

    }
    const clickHandler = () => {

    }
    const submithandler = (event) => {
        event.preventDefault()
        // event.SenderEmailChangeHandler()
        //emailjs.sendForm('service_r550zyb', 'template_19t6ohd', event.target, '')
    }
    return (
        <div className='container border' style={{ width: '50%', marginTop: '10px' }}>
            <form className='row' style={{ margin: '25px 85px 25px 85px' }} onSubmit={submithandler}>
                <select value={value} onChange={handleChanged} className="form-control" style={{ margin: "1rem" }}>
                    <option>Select Email Template</option>
                    <option>Birhthday Wishes</option>
                    <option>Festive Wishes</option>
                    <option>Seasonal Offers</option>
                </select>
                <input type='email' name='SenderEmail' placeHolder='sendersEmail' onChange={SenderEmailChangeHandler} className="form-control" style={{ margin: "1rem" }} />
                <input type='email' name='RecipientEmail' placeHolder='RecipientsEmail' onChange={RecipientEmailChangeHandler} className="form-control" style={{ margin: "1rem" }} />
                <input type='text' name='name' placeHolder='RecipientsName' onChange={RecipientNameChangeHandler} className="form-control" style={{ margin: "1rem" }} />
                <textarea placeHolder='Comments' name='message' rows='5' onChange={CommentChangeHandler} className="form-control" style={{ margin: "1rem" }} />
                <button type="button" onClick={clickHandler} className="form-control btn btn-primary" style={{ margin: "1rem" }}>Upload a File</button>
                <button type="submit" onClick={clickHandler} className="form-control btn btn-primary" style={{ margin: "1rem" }}>Send Mail</button>
            </form>
        </div>
    )
}

export default Email;