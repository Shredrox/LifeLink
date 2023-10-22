import React from 'react'
import Link from 'next/link'

const Button = ({content, style, path = '#'}) => {
  return (
    <button className={style}>
      <Link href={path}>{content}</Link>
    </button>
  )
}

export default Button