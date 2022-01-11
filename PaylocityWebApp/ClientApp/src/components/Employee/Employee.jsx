import React, { useState } from "react";
import ReactDOM from "react-dom";
import EmployeeForm from './EmployeeForm';
import BenefitTable from './BenefitTable';

const Employee = () => {

    const [employeeBenefit, setEmployeeBenefit] = useState(null);

    const onFormFinish = (values) => {
      console.log("Received values of form:", values);
      fetch('employee', {
        method: 'POST', 
        headers: {
          'Content-Type': 'application/json'
        }, 
        body: JSON.stringify(values) // body data type must match "Content-Type" header
      }).then(res => res.json()).then(response => {
          console.log("response::", response);
        setEmployeeBenefit(response);
      }).catch(ex=>{
          window.alert(ex.message);
      })
    };

    return (
      <div>
          <EmployeeForm onFormFinish={onFormFinish} />
          {employeeBenefit && <BenefitTable employeeBenefit={employeeBenefit} />}
      </div>
    );
   };
   
   export default Employee;