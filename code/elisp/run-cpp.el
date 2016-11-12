(defun run-cpp( fpath file-name-without-ext)
    "run cpp at the buffer"
    (interactive "sEnter file-path: 
sEnter exe-name: ")
    (compile "%s" (concat "g++ " fpath " -o " file-name-without-ext " -std=c++14" )))
    ;; (message "%s" (concat fpath file-name-without-ext)))
    ;; (message "%s%s" fpath file-name-without-ext ))

;; (defun run-cpp( x y)
;;     "run cpp at the buffer"
;;     (interactive "sEnter file-path: 
;; sEnter out: ")
;;     (message "%s%s" x y)) 
