import { Link } from "react-router-dom";

interface ButtonProps {
  content: string;
  style: string;
  path?: string;
}

const Button = ({content, style, path = '#'}: ButtonProps) => {
  return (
    <button>
      <Link className={style} to={path}>{content}</Link>
    </button>
  );
}

export default Button;
