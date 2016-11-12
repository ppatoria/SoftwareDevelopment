;; (defun test-function (number)
;;   (interactive "p")
;;   (* 7 number))
;(test-function 5)

;; (defun test-func (n1 n2)
;;   (* n1 n2))
  
(defun multiply-by-seven (number)       ; Interactive version.
  "Multiply NUMBER by seven."
  (interactive "p")
  (message "The result is %d" (* 7 number)))

