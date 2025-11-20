import { useState, useEffect} from 'react'
import viteIcon from '/vite.svg'
import reactIcon from './assets/react.svg'

function App() {
  const [count, setCount] = useState(0)

  return (
      <div className="min-h-screen flex flex-col items-center justify-center bg-brand">
        <div className="flex gap-15">
          <img src={viteIcon} alt="Vite Icon" className="w-30 h-30" />
          <img src={reactIcon} alt="React Icon" className="w-30 h-30" />
        </div>
        <h1 className="text-4xl font-bold text-white mt-6">
          Hello Tailwind v4 👋
        </h1>
      </div>
  )
}

export default App
