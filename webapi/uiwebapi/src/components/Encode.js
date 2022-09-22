import '../App.css';
import axios from 'axios';
import React, { useState } from 'react'
import configData from '../configuration.json';


export default function Encode() {

  const [dataInput, setDataInput] = useState();
  const [result, setResult] = useState();

  const submitHandler = async (event) => {
        event.preventDefault();
        try {
          
          const response = await axios.post(configData.SERVER_URL + '/api/v1/base64/encode',
          {
            input : dataInput
          });
          if (response.data) {
            setResult(response.data)             
          }else{
            console.log('empty');
          }
        } catch (error) {
          console.log(error);
        }
        
  }

  return (
    <div>
      <form onSubmit={submitHandler}>
          <div>
            <label>
              Enter word to encode
            </label>
            <input type='text' onChange={e => setDataInput(e.target.value)} required/>
          </div>

          <button type='submit'>
            Send
          </button>
      </form>

      {result && 
        <div className='rectangle'>
          {result.input}
        </div>}
    </div>
  )
}
