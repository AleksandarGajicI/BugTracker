import { ChangeEvent, useState } from "react";
import FormEventTarget from "./forms/FormEventTarget";

export function useForm(initialValue: any) {
  const [values, setValues] = useState({ ...initialValue });
  const [errors, setErrors] = useState<any>({});

  const handleInputChange = (
    e:
      | ChangeEvent<HTMLInputElement>
      | FormEventTarget
      | { target: { name: string; value: any } }
  ) => {
    console.log(e.target);
    const { name, value } = e.target;
    console.log(value);

    setValues({
      ...values,
      [name]: value,
    });
  };

  return {
    values,
    handleInputChange,
    errors,
    setErrors,
  };
}
