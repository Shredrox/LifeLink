import { Inter } from 'next/font/google'
import '@styles/globals.css'
import Header from '@components/Header'
import Footer from '@components/Footer'

const inter = Inter({ subsets: ['latin'] })

export const metadata = {
  title: 'LifeLink',
  description: 'A Bridge to Your Healthcare',
}

export default function RootLayout({ children }) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <Header />
        {children}
        <Footer />
      </body>
    </html>
  )
}