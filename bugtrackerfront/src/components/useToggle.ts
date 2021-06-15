import { useState } from "react";

export function useToggle(initialValue: Boolean) {
  const [isOpen, setIsOpen] = useState(initialValue);

  const toggle = () => {
    setIsOpen(!isOpen);
  };

  return {
    isOpen,
    toggle,
  };
}
