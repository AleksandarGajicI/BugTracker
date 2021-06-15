import { useState } from "react";

function useDialog() {
  const [open, setOpen] = useState(false);

  function toggle() {
    setOpen(!open);
  }

  return {
    open,
    toggle,
  };
}

export default useDialog;
