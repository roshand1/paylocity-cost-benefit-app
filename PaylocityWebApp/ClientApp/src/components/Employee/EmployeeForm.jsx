import React from "react";
import ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./employee.css"
import { Form, Input, InputNumber, Button, Space } from "antd";
import { MinusCircleOutlined, PlusOutlined } from "@ant-design/icons";

const EmployeeForm = ({onFormFinish}) => {
    const [form] = Form.useForm();

    const onFinish = (values) => {
      console.log("Received values of form:", values);
      onFormFinish(values);
    };

    function onChange(value) {
        console.log('changed', value);
    }

    return (
      <div className="employee-form">
            <Form
                form={form}
                name="dynamic_form_nest_item"
                onFinish={onFinish}
                autoComplete="off"
                >

                <Form.Item
                    name="EmployeeId"
                    label="Employee Id"
                    rules={[{ required: true, message: "Employee Id is required" }]}
                >
                    <Input placeholder="Employee Id" />
                </Form.Item>

                <Form.Item
                    name="FirstName"
                    label="First Name"
                    rules={[{ required: true, message: "First Name is required" }]}
                >
                    <Input placeholder="First Name" />
                </Form.Item>
                
                <Form.Item
                    name="LastName"
                    label="Last Name"
                    rules={[{ required: true, message: "Last Name is required" }]}
                >
                    <Input placeholder="Last Name" />
                </Form.Item>


                <Form.List name="Dependents">
        {(fields, { add, remove }) => (
          <>
            {fields.map(({ key, name, ...restField }) => (
              <Space
                key={key}
                style={{ display: "flex", marginBottom: 8 }}
                align="baseline"
              >
                <Form.Item
                  {...restField}
                  name={[name, "Type"]}
                  rules={[
                    { required: true, message: "Missing Dependent Type" }
                  ]}
                >
                  <Input placeholder="Spouse/Child1/Child2" />
                </Form.Item>
                <Form.Item
                  {...restField}
                  name={[name, "FirstName"]}
                  rules={[{ required: true, message: "Missing first name" }]}
                >
                  <Input placeholder="First Name" />
                </Form.Item>
                <Form.Item
                  {...restField}
                  name={[name, "LastName"]}
                  rules={[{ required: true, message: "Missing last name" }]}
                >
                  <Input placeholder="Last Name" />
                </Form.Item>
                <MinusCircleOutlined onClick={() => remove(name)} />
              </Space>
            ))}
            <Form.Item>
              <Button
                type="dashed"
                onClick={() => add()}
                block
                icon={<PlusOutlined />}>
                Add Dependent
              </Button>
            </Form.Item>
          </>
        )}
      </Form.List>

                
                <Form.Item
                    name="Submit Button"
                >
                    <Button type="primary" htmlType="submit">
                    Submit
                    </Button>
                </Form.Item>
            </Form>
      </div>
    );
   };
   
   export default EmployeeForm;