import { Link } from "react-router-dom";

interface Props {
  content: string;
  style: string;
  path?: string;
}

const Button:React.FC<Props> = ({content, style, path = '#'}) => {
  return (
    <button className={style}>
      <Link to={path}>{content}</Link>
    </button>
  )
}

export default Button
