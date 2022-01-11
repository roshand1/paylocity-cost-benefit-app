import React , { useState } from 'react';
import ReactDOM from 'react-dom';
import 'antd/dist/antd.css';
import { Table, Switch } from 'antd';

const BenefitTable = ({employeeBenefit}) => {

    const {firstName, lastName, costOfBenefitPerPayCheck, totalCostOfBenefit, dependents, employee
} = employeeBenefit || {};
    const [checkStrictly, setCheckStrictly] = useState(false);


    const columns = [
        {
          title: 'Name',
          dataIndex: 'name',
          key: 'name',
        },
        {
          title: 'BenefitCost',
          dataIndex: 'benefitCost',
          key: 'benefitCost',
          width: '12%',
        },
        {
          title: 'BenefitCostPerPaycheck',
          dataIndex: 'BenefitCostPerPaycheck',
          key: 'BenefitCostPerPaycheck',
          width: '12%',
        },
        {
          title: 'Salary',
          dataIndex: 'salary',
          width: '30%',
          key: 'salary',
        },
        {
          title: 'TotalYearlyBenefitCost',
          dataIndex: 'TotalYearlyBenefitCost',
          width: '30%',
          key: 'TotalYearlyBenefitCost',
        }
      ];
      debugger;
      var tableData = {
          key:1,
          name: employee.firstName + employee.lastName,
          BenefitCostPerPaycheck:employee.costOfBenefitPerPayCheck,
          benefitCost:employee.costOfBenefit,
          TotalYearlyBenefitCost:totalCostOfBenefit,
          salary:employee.salary
      };
      var newDependents = [];
      if(employee.dependents){
        employee.dependents.map(({firstName,lastName,costOfBenefit,costOfBenefitPerPayCheck}={}) => {
            newDependents.push({
              key:2,
              name:firstName+lastName,
              benefitCost:costOfBenefit,
              BenefitCostPerPaycheck:costOfBenefitPerPayCheck
          })
        });
      }
      tableData.children = newDependents;
      var newTableData =[];
      newTableData.push(tableData);
      
      
      // rowSelection objects indicates the need for row selection
      const rowSelection = {
        onChange: (selectedRowKeys, selectedRows) => {
          console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows);
        },
        onSelect: (record, selected, selectedRows) => {
          console.log(record, selected, selectedRows);
        },
        onSelectAll: (selected, selectedRows, changeRows) => {
          console.log(selected, selectedRows, changeRows);
        },
      };


    return (
      <div>
          <>
               { tableData && <Table
                    columns={columns}
                    rowSelection={{ ...rowSelection, checkStrictly }}
                    dataSource={newTableData}
                />
               }
          </>
      </div>
    );
   };
   
   export default BenefitTable;