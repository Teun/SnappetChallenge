import { useEffect, useRef } from "react"

const useScrollToTop = (value) => {
  const elementRef = useRef(null)
  useEffect(() => {
    if (elementRef && elementRef.current) {
      elementRef.current.scrollTo({
        top: 0,
        behavior: "smooth",
      })
    }
  }, [value, elementRef])
  return { elementRef }
}

export default useScrollToTop
